FROM nginx:latest

WORKDIR /usr/share/nginx/html

EXPOSE 80

COPY ./build/ .
CMD ["/bin/bash", "-c", "nginx -g \"daemon off;\""]