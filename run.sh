#!/bin/bash
set -e

if [ "$#" -lt 1 ]; then
  echo "Usage: $0 <project> [expected_result...]"
  exit 1
fi

project=$1
expected=${*:2}

result=$(dotnet run --project "$project")

if [ "$#" -eq 1 ]; then
  echo "$result"
else
  diff --color -w <(echo "$expected") <(echo "$result") && echo OK
fi
