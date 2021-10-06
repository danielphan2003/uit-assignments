{ pkgs ? import <nixpkgs> { config.allowUnfree = true; }, clangSupport ? false, cudaSupport ? false }:

with pkgs;
assert hostPlatform.isx86_64;

let
  mkCustomShell = mkShell.override { stdenv = if clangSupport then clangStdenv else gccStdenv; };
in
mkCustomShell {
  buildInputs = [
    # stdenv.cc.cc.lib
    # libcxxabi
    boost17x
    spdlog
    tbb
    zlib
  ] ++ lib.optionals (hostPlatform.isLinux) [ glibcLocales ];

  nativeBuildInputs = [ cmake gnumake ninja ] ++ [
    bashCompletion
    bashInteractive
    cacert
    clang-tools
    cmake-format
    cmakeCurses
    cmake-language-server
    cppcheck
    emacs-nox
    fmt
    gdb
    git
    less
    llvm
    more
    nixpkgs-fmt
    pkg-config
  ] ++ lib.optionals (hostPlatform.isLinux) [ typora ] ++ [ hugo ];

  LANG = "en_US.UTF-8";
  
  shellHook = ''
    export HOME=$(pwd);
    export SSL_CERT_FILE=${cacert}/etc/ssl/certs/ca-bundle.crt
  '';
}