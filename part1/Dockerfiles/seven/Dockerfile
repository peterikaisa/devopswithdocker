FROM ubuntu:16.04
COPY . .
RUN apt-get update && apt-get install -y curl
RUN chmod 755 ./script.sh

CMD ["sh", "-c", "./script.sh"]