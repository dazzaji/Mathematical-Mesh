# Using the `hash` Command Set

The `hash` command set contains commands that perform Content Digest and 
Message Authentication Code operations on the contents of a file.

## Calculating Content Digests

The `hash udf`  command calculates the UDF value of a file:


````
>hash udf TestFile1.txt
MDLI-GX2C-3OQB-BVWI-REXY-EB56-JG4R
````

In this case, the file `TestFile1.txt` contains the text `"This is a test"`.

By default, a SHA-2-512 digest is created and the IANA Media Type parameter is
determined from the file extension of the file being processed. These defaults
may be overriden using the `/cty` and `/alg` options:


````
>hash udf TestFile1.txt /cty=application/binary
MDBI-EE4Z-7NSH-SYBU-JHYL-JTGH-QQEZ
>hash udf TestFile1.txt /alg=sha3
KCYH-QB5Y-XZ6U-SXN2-WV63-AM4U-ZZIT
````

By default, UDF values are given to 140 bit precision. Higher precision may be
specified with the `/bits' option:


````
>hash udf TestFile1.txt /bits=200
MDLI-GX2C-3OQB-BVWI-REXY-EB56-JG4R-NYJQ-SWWT-UNJM
````

If the expected digest value is specified, this is used to check the calculated value:


````
>hash udf TestFile1.txt /expect=MDLI-GX2C-3OQB-BVWI-REXY-EB56-JG4R
True
>hash udf TestFile1.txt /expect=MDBI-EE4Z-7NSH-SYBU-JHYL-JTGH-QQEZ
ERROR - The calculated fingerprint did not match the expected value.
````

The `hash digest`  command calculates the SHA-2-512 digest and
returns it in hexadecimal form:


````
>hash digest TestFile1.txt
A028D4F74B602BA45EB0A93C9A4677240DCF281A1A9322F183BD32F0BED82EC72DE9C3957B2F4C9A1CCF7ED14F85D73498DF38017E703D47EBB9F0B3BF116F69
````

Additional digest algorithms may be specified using the `/alg` option:


````
>hash digest TestFile1.txt /alg=sha256
C7BE1ED902FB8DD4D48997C6452F5D7E509FBCDBE2808B16BCF4EDCE4C07D14E
>hash digest TestFile1.txt /alg=sha3256
3C3B66EDCFE51F5B15BF372F61E25710FFC1AD3C0E3C60D832B42053A96772CF
>hash digest TestFile1.txt /alg=sha3
CE548503582D94B17898E45B1B641E97BE64DC23947890E8F5199E474819E7F94B5A0D55B41D2CCC01D0C37C978F1F2523BD294B7E282E36E20C39C84CC2730E
````

## Calculating UDF Message Authentication Codes

The `hash mac` command calculates a Message Authentication Code (MAC)
over the file contents and presents it in UDF format:

A MAC may be used to create a keyed commitment value that can be used to provide
proof that a document existed at a particular time without revealing information 
that might allow disclosure of a short or otherwise predictable document by a 
brute force attack.

If no key is specified, a random secret is generated:


````
>hash mac TestFile1.txt
ABHF-OSIX-RFRN-ATT3-3HME-EVFH-MLGK
NCU6-YNCI-T227-7TPB-KZJK-T4FG-IVAJ
````

A key may be specified using the `/key` option:


````
>hash mac TestFile1.txt /key=NCU6-YNCI-T227-7TPB-KZJK-T4FG-IVAJ
ABHF-OSIX-RFRN-ATT3-3HME-EVFH-MLGK
NCU6-YNCI-T227-7TPB-KZJK-T4FG-IVAJ
````

If the expected digest value is specified, this is used to check the calculated value:



````
>hash mac TestFile1.txt /key=NCU6-YNCI-T227-7TPB-KZJK-T4FG-IVAJ /expect=ABHF-OSIX-RFRN-ATT3-3HME-EVFH-MLGK
True
>hash mac TestFile1.txt /key=NCU6-YNCI-T227-7TPB-KZJK-T4FG-IVAJ /expect=MDLI-GX2C-3OQB-BVWI-REXY-EB56-JG4R
ERROR - The calculated fingerprint did not match the expected value.
````


