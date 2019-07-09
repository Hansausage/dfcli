#!/bin/bash
mkdir build
msbuild dfcli.csproj -t:Build -p:OutDir=build
