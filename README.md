# CrypTool
#### Check your hashes and erase files

## What is this
> CrypTool is a simplistic tool used to generate and compare MD5- and SHA256-hashes.
> 
> Additionally, CrypTool has an option to erase a file before you can delete the files
> empty husk.

## How to use
#### Generating Hashes
> * Select a file by clicking on the [Select File] button
> * Choose a hashing algorithm by either pressing the [Calculate MD5] or the [Calculate SHA256] button
> * Either copy the hash from the Output-textbox or export it by pressing on the [Save Output] button

#### Comparing Hashess
> * Select a downloaded file by clicking on the [Select File] button
> * Enter the hash provided by the developer of the file in the hash-textbox
> * If the developer provided you with a MD5-hash, press the [Compare MD5] button
> * If the developer provided you with a SHA256-hash, press the [Compare SHA256] button
>
> If the file was validated, the Output-textbox will show ```"Validated: Success"``` at the bottom.
> If the file was tampered with or damaged, the Output-textbox will show ```"Validated: Failure"``` at the bottom
> * If you want to save this comparison, press the [Save Output] button and export the comparison as a TXT

#### Erasing Files
##### THIS PROCESS CAN NOT BE REVERSED
> * Select a file by clicking on the [Select File] button
> * Press the [Erase File Contents] button (highlighted in red)
> * The selected file will be filled with ```bytevalue 0```
> * Now you can delete your file yourself, with all data in it expunged
