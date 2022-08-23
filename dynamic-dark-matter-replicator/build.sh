#!/bin/bash
FACTIORIO_PATH=/mnt/c/Users/Aidan/AppData/Roaming/Factorio/mods/

INFO_JSON=info.json
JQ_ARGS=.version
JQ_RESPONSE=$(cat $INFO_JSON | jq -r "$JQ_ARGS")

MOD_NAME=dynamic-dark-matter-replicator
ZIP_NAME="$MOD_NAME""_""$JQ_RESPONSE"".zip"

zip -r $ZIP_NAME . -x build.sh

rm $FACTIORIO_PATH$ZIP_NAME
mv $ZIP_NAME $FACTIORIO_PATH