#!/bin/bash
echo "$DOCKER_PASSWORD" | docker login -u "$DOCKER_USERNAME" --password-stdin
docker push artsdatabanken/identity
docker push artsdatabanken/identityadmin
curl -X POST --data-urlencode "payload={\"channel\": \"$slack_chan\", \"username\": \"travis not the band\", \"text\": \"$slack_command\", \"icon_emoji\": \":ghost:\"}" https://hooks.slack.com/services/$SLACK_TOKEN