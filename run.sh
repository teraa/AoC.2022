#!/bin/bash

if [ "$#" -lt 1 ]; then
    echo "Usage: $0 <project> [expected_result...]"
    exit 1
fi

project=$1
expected=${@:2}
cd $1

if [ "$#" -eq 1 ]; then
    dotnet run
else
    dotnet run | diff --color -w <(echo "$expected") - && echo OK
fi
