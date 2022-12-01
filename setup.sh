#!/bin/bash
set -e

add() {
  set_vars
  echo "Adding $prefix"

  for part in {a,b}; do
    project=$prefix.$part
    dotnet new aoc2022 -n $project
    dotnet sln add $project -s Puzzles
  done

  # .headers file format
  # Cookie: <cookie>
  # user-agent: <user agent>

  curl "https://adventofcode.com/$year/day/$day/input" -H @.headers -sSL \
  | tee $prefix.{a,b}/input.txt 1> /dev/null

  git add $prefix.{a,b}
}

remove() {
  set_vars
  echo "Removing $prefix"

  dotnet sln remove $prefix.{a,b}
  rm -r $prefix.{a,b}
  git add $prefix.{a,b}
}

set_vars() {
  day=$OPTARG
  printf -v prefix "Day%02d" $day
}

: ${year:=2022}

while getopts "a:r:y:" arg; do
  case $arg in
    a) add;;
    r) remove;;
    y) year=$OPTARG;;
  esac
done
