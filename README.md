# Security Course ICI002AS2AE 2023
## W03
## W04
### Owasp Top 10 - A08 Software and Data Integrity Failures
- Happens when an application relies on content that is delivered through an insecure pipeline
- Avoid by checking the integrity of the content: Use digital signature, have a secure pipeline, use software supply chain security tools

**Attack Scenario**

A user updates a software using a public network, and the software installer has no checksum. The user has downloaded a malicious modified version of the software