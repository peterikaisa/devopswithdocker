# Part 1

### 1.1 Getting started

![Answer](./im/started.PNG)

### 1.2 Cleanup

![Answer](./im/started2.PNG)

### 1.3 Hello Docker Hub

![Answer](./im/secret.PNG)

### 1.4

![Answer](./im/four.PNG)

### 1.5

The easiest, simplest method that I came up with

```
docker run -it -d --name ubuntu ubuntu:16.04 // let's run an ubuntu image in a (detached) container
docker exec -it ubuntu sh // invade that juicy container with shell
```
Once connected to the shell: (following magic happens inside the container)

```
(# apt update // optional, I guess, if the next one works ok, I don't really know unix systems that well, man)
# (sudo) apt install curl
(# curl helsinki.fi // for testing, if unsure like I am)
# exit // get out
```
And now we have a container running ubuntu with curl installed and can run the given shell script

![Answer](./im/five.PNG)

### 1.6

[Dockerfile](./Dockerfiles/six/Dockerfile.1)

![Answer](./im/six.PNG)