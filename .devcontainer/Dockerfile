FROM mono:latest as build

ENV DOTNET_CLI_TELEMETRY_OPTOUT=1

RUN apt update
RUN apt upgrade -y
RUN apt install git-all wget apt-transport-https -y

RUN wget https://packages.microsoft.com/config/ubuntu/20.10/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
RUN dpkg -i packages-microsoft-prod.deb
RUN rm packages-microsoft-prod.deb

FROM build
RUN apt-get update
RUN apt-get install -y dotnet-sdk-5.0
RUN apt-get install -y aspnetcore-runtime-5.0
