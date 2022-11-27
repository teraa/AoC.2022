#!/bin/bash
set -e

year=2021

add() {
  set_vars
  echo "Adding $prefix"

  for part in {a,b}; do
    project=$prefix.$part
    dotnet new aoc2022 -n $project
    dotnet sln add $project -s Puzzles
  done

  # .cookie file format
  # Cookie: <cookie>

  curl "https://adventofcode.com/$year/day/$day/input" -H @.cookie -sSL \
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

while getopts "a:r:" arg; do
  case $arg in
    a) add;;
    r) remove;;
  esac
done