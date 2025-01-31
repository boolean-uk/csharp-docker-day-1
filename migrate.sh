#!/bin/sh
dotnet ef database update
exec "$@