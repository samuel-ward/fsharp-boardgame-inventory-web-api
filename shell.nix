{ pkgs ? import <nixpkgs> {} }:

with pkgs;

stdenv.mkDerivation {
  name = "games-shelf-backend-shell";
  buildInputs = [
    awscli
    dotnetCorePackages.sdk_8_0
    /* The below should be used when migrating dotnet versions
    dotnetCorePackages.combinePackages [
      dotnet-sdk_8_0
      # Add new versions here when migrating - next LTS version is 10 in 2025
    ]
    */
  ];
}
