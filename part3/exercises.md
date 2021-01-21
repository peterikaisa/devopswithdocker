# Part 3

## 3.1

(To make things easier, I am doing these changes straight into the original Dockerfile to avoid having to duplicate the original code. The file can be seen as it was before changes [in part 1] from commit history. I wish I had known beforehand that I would be using these example projects in all three sections of this course, then I would have put them in a separate folder instead of putting them under the part that it was introduced in.)

### Backend

Backend Dockerfile before changes:

```Dockerfile
FROM ubuntu:16.04
EXPOSE 8000
ENV FRONT_URL="http://localhost:5000"

WORKDIR /usr/app
COPY . .
RUN apt-get update && apt-get install -y curl
RUN curl -sL https://deb.nodesource.com/setup_14.x | bash
RUN apt-get install -y nodejs && npm install
CMD [ "sh", "-c", "npm start" ]
```

Backend image history before changes:

![Backend](./one/backendbefore.PNG)

Backend Dockerfile after changes:

```Dockerfile
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
    rm -rf /var/lib/apt/lists/*

EXPOSE 8000
CMD [ "sh", "-c", "npm start" ]
```

Backend image history after changes:

![Backend](./one/backendafter.PNG)

Frontend Dockerfile before changes:

```Dockerfile
FROM ubuntu:16.04
EXPOSE 5000
ENV API_URL="http://localhost:8000"

WORKDIR /usr/app
COPY . .
RUN apt-get update && apt-get install -y curl
RUN curl -sL https://deb.nodesource.com/setup_14.x | bash
RUN apt-get install -y nodejs && npm install
CMD [ "sh", "-c", "npm start" ]
```

Frontend image history before changes:

![Front](./one/frontbefore.PNG)

Frontend Dockerfile after changes:

```Dockerfile
FROM ubuntu:16.04

WORKDIR /usr/app
COPY . .

RUN apt-get update && \
    apt-get install -y curl && \
    curl -sL https://deb.nodesource.com/setup_14.x | bash && \
    apt-get install -y nodejs && \
    npm install && \
    apt-get purge -y --auto-remove curl && \
    rm -rf /var/lib/apt/lists/*

ENV API_URL="http://localhost:8000"
EXPOSE 5000
CMD [ "sh", "-c", "npm start" ]
```

Frontend image history after changes:

![Front](./one/frontafter.PNG)

### 3.2

Github https://github.com/peterikaisa/sample-project

Docker Hub https://hub.docker.com/r/peterikaisa/sample-project

Heroku https://sample-project-k.herokuapp.com/

### 3.4

[Backend dockerfile](..\part1\Dockerfiles\backend-example-docker-master\Dockerfile)

[Frontend dockerfile](..\part1\Dockerfiles\frontend-example-docker-master\Dockerfile)

Added changes to both (both located in part1 folder)

```Dockerfile
    && \
    useradd -m app && \
    chown -R app .
    
USER app
```

### 3.5

Image sizes are as in 3.1 (after 3.1 changes). To maintain some consistency between the exercises I made new dockerfiles for this exercise for both example projects titled `Dockerfile.smol`. Since the projects are build straight from the dockerfiles the apps don't obviously have any of the functionality defined in part 2, so when running them both only exercises 1.10 and 1.12 work.

[Backend dockerfile](..\part1\Dockerfiles\backend-example-docker-master\Dockerfile.smol)

[Frontend dockerfile](..\part1\Dockerfiles\frontend-example-docker-master\Dockerfile.smol)

![Smol backend](./five/backsmol.PNG)

![Backend diff](./five/backdiff.PNG)

![Smol front](./five/frontsmol.PNG)

![Front diff](./five/frontdiff.PNG)

### 3.6

Once again, I made a new dockerfile called `Dockerfile.multi` for clarity.

[Dockerfile](..\part1\Dockerfiles\frontend-example-docker-master\Dockerfile.multi)

### 3.7

I modified the dockerfile in the rails project provided by this course. Original [dockerfile](..\part1\Dockerfiles\rails-example-project-master\Dockerfile) located in part 1.

```Dockerfile
FROM ruby:2.6.0

RUN apt-get update && apt-get install -y curl
RUN curl -sL https://deb.nodesource.com/setup_14.x | bash
RUN apt-get install -y nodejs

COPY Gemfile Gemfile.lock ./
RUN bundle install
COPY . .
RUN rails db:migrate
CMD [ "rails", "s" ]
```

Added changes include mostly removing separate layers from different RUN commands, removing curl afterwards and adding a non-root user. I tried making the app run in production mode, but I kept getting a 'missing secret_key_base' error and I don't now ruby at all nor do I know how it builds its assets for production, so it is what it is. There really wasn't any change in the image size * shrug *.

[Dockerfile](..\part1\Dockerfiles\rails-example-project-master\Dockerfile.opt)

```Dockerfile
FROM ruby:2.6.0

WORKDIR /app

COPY . .

RUN apt-get update && \
    apt-get install -y curl && \
    curl -sL https://deb.nodesource.com/setup_14.x | bash && \
    apt-get install -y nodejs && \
    apt-get purge -y --auto-remove curl && \
    bundle install && \
    rails db:migrate && \
    rake assets:precompile && \
    useradd -m ruby && \
    chown -R ruby .

USER ruby

CMD [ "rails", "s" ]
```

### 3.8

![Diagram](./eight/kubernetes.png)