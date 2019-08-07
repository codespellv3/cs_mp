FROM ubuntu:18.04

WORKDIR /unity

COPY startServer.sh ./
COPY linuxServer/ ./

EXPOSE 7777/tcp
EXPOSE 7777/udp

CMD ./startServer.sh

