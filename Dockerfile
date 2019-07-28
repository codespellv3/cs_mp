FROM ubuntu:18.04

WORKDIR /unity

COPY headless_Data ./headless_Data
COPY headless.x86_64 ./
COPY startServer.sh ./

EXPOSE 7777/tcp
EXPOSE 7777/udp

CMD ./startServer.sh

