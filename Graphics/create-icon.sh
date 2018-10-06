#!/usr/bin/env bash

set -e
set -u
set -o pipefail

declare -r INPUT_PATH="$1"
shift

declare -r COLOR_BACKGROUND="${1:-none}"
shift

declare -r INPUT_BASENAME="$(basename "${INPUT_PATH%.*}")"
declare -r OUTPUT_DIRECTORY="icon/${INPUT_BASENAME}/"
declare -r OUTPUT_BASEPATH="icon/${INPUT_BASENAME}/${INPUT_BASENAME}"

mkdir -p "$OUTPUT_DIRECTORY"

convert \
    -background $COLOR_BACKGROUND \
    -density '2048' \
    -extent '2048x2048!' \
    -resize '2048x2048' \
    -gravity 'center' \
    "$INPUT_PATH" \
    -format 'ico' \
    -define 'icon:auto-resize=256,96,64,48,40,24,20,16' \
    "${OUTPUT_BASEPATH}.ico"

for size in 16x16 32x32 48x48 64x64 96x96 128x128 256x256 512x512 1024x1024 2048x2048;
do
    convert \
        -background $COLOR_BACKGROUND \
        -density '2048' \
        -extent '2048x2048!' \
        -resize '2048x2048' \
        -gravity 'center' \
        "$INPUT_PATH" \
        -resize "$size" \
        -extent "${size}!" \
        -alpha set "${OUTPUT_BASEPATH}-${size}.png"
done
