using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Xml;


namespace RSA_Factoring_CSharp
{
    /// <summary>
    /// Finds p * q = n where n is a modulus found in an X509 certificate by finding common factors in a given set of certificates
    /// </summary>
    class Program
    {
        /// <summary>
        /// Generates a list of all 2-combinations in an BigInteger array
        /// </summary>
        /// <param name="list">A BigInteger array larger than 2</param>
        /// <returns>A list of BigInteger arrays of size 2</returns>
        static List<BigInteger[]> GeneratePairsOfModulus(BigInteger[] list)
        {
            if (list.Length < 2) throw new Exception("You need at least two certificates to run this program");
            //Knowing C(n,r) = n! / (r!(n - r)!), calculate the size of the list
            // n = NumberOfModulus
            //r = 2
            List<BigInteger[]> result = new List<BigInteger[]>();

            for (int i = 0; i < list.Length - 1; i++)
            {
                for (int j = i + 1; j < list.Length; j++)
                {
                    BigInteger[] combination = { list[i], list[j] };
                    result.Add(combination);
                }
            }
            return result;
        }

        /// <summary>
        /// Finds modulus in a X509 certificate file
        /// </summary>
        /// <param name="certificateFile">The certificate file</param>
        /// <returns>The modulus in a BigInteger</returns>
        static BigInteger ReadModulus(string certificateFile)
        {
            if (!certificateFile.EndsWith(".pem")) throw new Exception("Files must be .pem certificates");

            //Creates an X509Certificate object
            string certPem = File.ReadAllText(certificateFile);
            certPem = certPem.Replace("-----BEGIN CERTIFICATE-----", null).Replace("-----END CERTIFICATE-----", null);
            X509Certificate2 cert = new X509Certificate2(Convert.FromBase64String(certPem));
            
            // Creates an xml file corresponding to the public key and parses the <modulus> value
            string publicKeyXml = cert.GetRSAPublicKey().ToXmlString(false);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(publicKeyXml);
            string xpath = "RSAKeyValue/Modulus";
            string modulusValueSubstring = doc.SelectSingleNode(xpath).InnerText;

            // Converts string value to unsigned BigInteger
            byte[] modulusBytes = Convert.FromBase64String(modulusValueSubstring);
            ReadOnlySpan<byte> bytesReadOnlySpan = modulusBytes;
            BigInteger modulus = new BigInteger(bytesReadOnlySpan, true, true);
            return modulus;
        }

        static void Main(string[] args)
        {
            string rootFolder = args[0];

            string[] files = Directory.GetFiles(rootFolder);
            BigInteger[] modulus = new BigInteger[files.Length];

            long start = DateTime.Now.Ticks;
            for (int i = 0; i < files.Length; i++)
                modulus[i] = ReadModulus(files[i]);

            List<BigInteger[]> pairOfModulus = new List<BigInteger[]>(GeneratePairsOfModulus(modulus));

            /* Parallel.ForEach
             * "The loop partitions the source collection and schedules the work on multiple threads based on the system environment.
             *  The more processors on the system, the faster the parallel method runs."
             * (https://docs.microsoft.com/en-us/dotnet/standard/parallel-programming/how-to-write-a-simple-parallel-foreach-loop)
             *  Performance is directly linked to the number of logical cores available
             */
            List<BigInteger[]> solutions = new List<BigInteger[]>();
            Parallel.ForEach(pairOfModulus, pair =>
             {
                 BigInteger gcd = BigInteger.GreatestCommonDivisor(pair[0], pair[1]);

                 if (gcd.IsOne) return;

                 // gcd is greater than one, so we have found a common factor. It's now easy to compute n = p*q.
                 BigInteger q = pair[0] / gcd;
                 solutions.Add(new BigInteger[] { pair[0], gcd, q });

                 q = pair[1] / gcd;
                 solutions.Add(new BigInteger[] { pair[1], gcd, q });

             });

            long end = DateTime.Now.Ticks - start;
            Console.WriteLine("In: " + end / 10000 + "ms");

            Console.WriteLine("Found " + solutions.Count + " solutions\nList them all ?");

            var ans = Console.ReadLine();
            if (ans.StartsWith('y'))
            {
                foreach (var sol in solutions)
                {
                    for(int i = 0; i<modulus.Length; i++)
                    {
                        if (modulus[i].Equals(sol[0]))
                        {
                            Console.WriteLine(files[i]);
                        }
                    }
                    Console.WriteLine(sol[0] + "\n=");
                    Console.WriteLine(sol[1] + "\n * ");
                    Console.WriteLine(sol[2] + "\n\n");
                }
            }

        }
    }
}
