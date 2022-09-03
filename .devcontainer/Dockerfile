FROM mcr.microsoft.com/dotnet/sdk:6.0-jammy

# Install Azure Functions Core Tools
RUN wget -q https://packages.microsoft.com/config/ubuntu/22.04/packages-microsoft-prod.deb \
    && dpkg -i packages-microsoft-prod.deb \
    && apt-get update \
    && apt-get install -y azure-functions-core-tools-4 \
    && dotnet tool install --global dotnet-ef

# Adding dotnet tools to path
ENV PATH="${PATH}:/root/.dotnet/tools"