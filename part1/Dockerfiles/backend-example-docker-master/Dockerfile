FROM ubuntu:16.04

ENV FRONT_URL="http://localhost:5000"

WORKDIR /usr/app
COPY . .

RUN apt-get update && \
    apt-get install -y curl && \
    curl -sL https://deb.nodesource.com/setup_14.x | bash && \
    apt-get install -y nodejs && \
    npm install && \
    apt-get purge -y --auto-remove curl && \
    rm -rf /var/lib/apt/lists/* && \
    useradd -m app && \
    chown -R app .
    
USER app

EXPOSE 8000
CMD [ "sh", "-c", "npm start" ]