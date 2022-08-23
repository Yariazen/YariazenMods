#!/bin/bash
FACTIORIO_PATH=/mnt/c/Users/Aidan/AppData/Roaming/Factorio/mods/
MOD_NAME=dynamic-dark-matter-replicator

INFO_JSON=info.json
JQ_ARGS=.version
JQ_RESPONSE=$(cat $INFO_JSON | jq -r "$JQ_ARGS")

ZIP_NAME="$MOD_NAME""_""$JQ_RESPONSE"".zip"

python=`cat <<HEREDOC
import zipfile, os

def zipDir(path, ziph):
    for root, dirs, files in os.walk(path):
        for file in files:
            if(file != "build.sh" and file != '$ZIP_NAME'):
                print("Adding:\t{}".format(os.path.relpath(os.path.join(root, file))))
                ziph.write(os.path.join(root, file), os.path.relpath(os.path.join(root, file), os.path.join(path, '..')))

with zipfile.ZipFile('$ZIP_NAME', 'w', zipfile.ZIP_DEFLATED) as ziph:
    zipDir('.', ziph)
HEREDOC
`

python3 -c "$python"

if [ -f $FACTIORIO_PATH$ZIP_NAME ]; then
    rm $FACTIORIO_PATH$ZIP_NAME
fi
mv $ZIP_NAME $FACTIORIO_PATH