#!/bin/bash
export DOTNET_ROOT=/usr/local/share/dotnet
export PATH=$DOTNET_ROOT:$PATH
dotnet publish -c Release -o output
