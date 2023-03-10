# Homework 4 - hash

## x) Read and summarize (This subtask x does not require tests with a computer. Some bullets per article is enough for your summary, feel free to write more if you like)
### € Schneier 2015: Applied Cryptography: 2.3 One-Way Functions and 2.4 One-Way Hash Functions.
**2.3**
- One-way functions are function that are easy to compute but hard to reverse.
- Given x, it is easy to compute f(x)
- Given f(x), it is hard to compute x
- They are no real evidence of one-way functions
- Trapdoor one-way function are functions that are easy to compute in reverse but only equipped with a secret.

**2.4**
- Hash functions can be called: compression f, contraction f, message digest, fingerprint, cryptographic fingerprint, message integrity check, manipulation detection code.
- Hash functions are used in many protocols.
- Takes a variable length input and converts it to a fixed-length output.
- Because hash functions are many-to-one, they are not certain to with certainty that two things are equal, but still with reasonable assurance.
- Good (useful) hash functions are one-way and relatively collision-free
- Good (useful) hash functions are public and make it so that given the output, it is computationally impossible to find the original value (pre-image).
- Useful to fingerprint files, for example.
- Add a key to the pre-image to make it impossible for people without the key to verify the hash value.

## a) Install Hashcat. See Karvinen 2022: Cracking Passwords with Hashcat
I already had Hashcat installed.

```shell
sudo apt-get install hashcat
```

## b) Crack this hash: 8eb8e307a6d649bc7fb51443a06a216f
According to hash id the hash algorithm is md5. We know that md5 is identified as '0' by Hashcat. Let's use a dictionary attack on the hash using rockyou and hashcat.

```shell
hashcat -m 0 -a 0 -o h4_ans 8eb8e307a6d649bc7fb51443a06a216f rockyou.txt
cat h4_ans
```

The password is february.

## c) Compile John the Ripper, Jumbo version. Karvinen 2023: Crack File Password With John.
1. First install the dependencies:
```shell
sudo apt-get -y install micro bash-completion git build-essential libssl-dev zlib1g zlib1g-dev zlib-gst libbz2-1.0 libbz2-dev atool zip wget
```
2. Clone the source repository to your machine
```shell
git clone --depth=1 https://github.com/openwall/john.git
```
3. Run configure
```shell
john/src/configure
```
4. Compile the software from source
```shell
make -s clean && make -sj4
```
5. You now should have the compiled program in the "run" directory
```shell
cd ../run
ls
john
```
## d) Crack a zip file password
1. Download Tero's file
```shell
cd ~
wget https://TeroKarvinen.com/2023/crack-file-password-with-john/tero.zip
```
2. Notice that the file is password protected
3. Extract the hash using zip2john
```shell
./john/run/zip2john tero.zip > tero_zip.hash
```
4. Use john to perform a dictionary attack on the hashed password
```shell
john/run/john tero_zip.hash
```
5. Read the password **butterfly**
6. Unzip Tero's folder and read its content
```shell
unzip tero.zip
butterfly
cd secretFiles
cat SECRET.md
```