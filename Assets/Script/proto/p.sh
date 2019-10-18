#!/usr/bin/env bash

#过滤rpc_*.proto
protoc  --csharp_out=. *.proto

