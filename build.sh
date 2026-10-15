#!/usr/bin/env bash
set -e

# Install .NET 9 SDK in Vercel Linux container if not available
if ! command -v dotnet &> /dev/null; then
  echo "Installing .NET SDK 9.0..."
  export DOTNET_ROOT="/tmp/dotnet"
  mkdir -p "$DOTNET_ROOT"
  curl -sSL https://dot.net/v1/dotnet-install.sh -o "$DOTNET_ROOT/dotnet-install.sh"
  bash "$DOTNET_ROOT/dotnet-install.sh" --channel 9.0 --install-dir "$DOTNET_ROOT"
  export PATH="$DOTNET_ROOT:$PATH"
fi

echo "Active .NET SDK:"
dotnet --version

echo "Publishing Blazor WebAssembly..."
dotnet publish Frontend.Web/Frontend.Web.csproj -c Release -o dist
