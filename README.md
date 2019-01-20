# Docker by Example

Demonstrating how to get ASP.NET Core and Django development environments up and running with Docker and Docker Compose.

There are slides I have prepared to go along with this repository.  You can find it in the root project folder as `Intro to Docker.pdf`.

# Running Each Environment

## Django

All commands below are executed from within the `django` folder unless noted otherwise.

1. `docker-compose up -d` to spin up the containers
1. If this is the first time your containers have been built, you will have to apply database migration scripts before the app will function.  To do that, run:

    `docker exec -it django_app_1 python manage.py migrate`

    If you're not sure whether you've run that command already, don't worry, it won't re-apply migrations you applied previously.

1. On your host machine, navigate to http://localhost:8000/api/ideas

### Known Issues

If you make code changes to the Django project outside of the container, those changes will be reflected immediately.  Sometimes, syntactical errors or Python exceptions may cause the `django_app_1` container to stop.  Simply run `docker-compose up -d` again to start it back up.

## ASP.NET Core

All commands below are executed from within the `aspnetcore` folder unless noted otherwise.

### Development Environment

The source code in the `aspnetcore` directory is bind-mounted to the container's filesystem.  This environment's `app` service runs a file watcher so that ASP.NET Core automatically reloads after code changes.

1. `docker-compose -f docker-compose.yml -f docker-compose.dev.yml up -d` to spin up the containers
2. There's no need to apply migrations manually here, as this project has been set up to apply migrations during app startup.
3. On your host machine, navigate to http://localhost:8080/api/ideas

### Non-development Environment

**This is very much not a real production environment.**  There are online resources on getting your containers production-ready, which are beyond the scope of this project.  A good place to start is Docker's own [Use Compose in Production](https://docs.docker.com/compose/production/).

In this variation, we copy our source code into our own custom ASP.NET Core runtime image and compile it using a Release configuration.  This custom image is given a name and a tag, which allows it to be pushed to a Docker image registry and re-used by others.

This variation does _not_ auto-reload upon changes to the code in our host machine, because the building, compiling and running of our application is all part of the Docker image build process.  If this was a real production image, this helps keep our image size small and focused solely on running in production.

1. `docker-compose -f docker-compose.yml -f docker-compose.prod.yml up -d` to spin up the containers.  Note the use of `docker-compose.prod.yml` as the follow-up Compose file instead of `.dev.yml`
2. There's no need to apply migrations manually here, as this project has been set up to apply migrations during app startup.
3. On your host machine, navigate to http://localhost:8080/api/ideas

# Suspending and (Re)starting your Environment

`docker-compose stop`: Stops the containers, you can think of it like suspending a virtual machine.
`docker-compose start`: Starts the containers you previously stopped

# Tearing Down your Environment

1. To tear down your containers (effectively deleting them), navigate to the project you'd like to tear down and run `docker-compose down`
1. Your database's volumes will be kept around, because volumes can be shared amongst containers (even those outside of your Compose file!).  To remove volumes that aren't currently in use by a running container, run `docker volume prune`

# Contributing

Please file issues to ask questions and provide constructive feedback.  If you're feeling extra nice, I welcome pull requests too.  My hope is that this repository becomes an even more useful teaching tool as time goes on.
