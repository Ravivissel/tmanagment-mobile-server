FROM microsoft/aspnetcore-nightly
WORKDIR /app
COPY . .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet MobileTmanaGment.dll
