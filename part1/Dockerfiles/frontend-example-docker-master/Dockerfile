FROM ubuntu:16.04
EXPOSE 5000

WORKDIR /usr/app
COPY . .
RUN apt-get update && apt-get install -y curl
RUN curl -sL https://deb.nodesource.com/setup_14.x | bash
RUN apt-get install -y nodejs && npm install
CMD [ "sh", "-c", "npm start" ]