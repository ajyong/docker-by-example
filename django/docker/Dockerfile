FROM python:3-alpine
ENV PYTHONUNBUFFERED 1
RUN apk --no-cache add build-base
RUN apk --no-cache add postgresql-dev
RUN pip3 install pipenv
RUN mkdir /code
WORKDIR /code
COPY ./app /code/
RUN set -ex && pipenv install --system --deploy
