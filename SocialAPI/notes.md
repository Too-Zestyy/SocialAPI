## Generating ECDsa keypairs for use with API
Generate a key containing the pair with:
```bash
openssl ecparam -name prime256v1 -genkey -outform pem -out keypair.pem
```
*(The curve used via `-name` can be changed for preference)*

---
Extract the public key from the pair with:
```bash
openssl ec -in keypair.pem -pubout -out public.pem
```