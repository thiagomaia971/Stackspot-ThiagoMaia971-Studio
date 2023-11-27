#!/bin/bash

version=$1
studio=$2
versionText="  version: ${version}"
mylist=$(find ./ -type f -wholename "./plugins/*/plugin.yaml")

for file in $mylist; do
    echo $file
    sed -i "7s/.*/${versionText}/" $file
    (cd ${file%/*}; echo $(pwd); stk publish plugin -s $2)
done
