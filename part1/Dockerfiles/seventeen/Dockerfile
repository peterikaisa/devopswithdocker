FROM mcr.microsoft.com/dotnet/sdk:3.1
WORKDIR /usr/app/source
RUN dotnet new console

WORKDIR /usr/app/tests
COPY tests/ .
RUN dotnet add package xunit --version 2.4.1
RUN dotnet add package xunit.runner.visualstudio --version 2.4.1

CMD [ "bin/bash" ]