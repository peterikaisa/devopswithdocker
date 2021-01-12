FROM ruby:2.6.0

RUN apt-get update && apt-get install -y curl
RUN curl -sL https://deb.nodesource.com/setup_14.x | bash
RUN apt-get install -y nodejs

COPY Gemfile Gemfile.lock ./
RUN bundle install
COPY . .
RUN rails db:migrate
CMD [ "rails", "s" ]