FROM nginx:latest

ARG ReactAppApiUrl
ENV REACT_APP_API_URL $ReactAppApiUrl

ARG ReactAppApiKeyHeader
ENV REACT_APP_API_KEY_HEADER $ReactAppApiKeyHeader

EXPOSE 80

COPY ./build/ /usr/share/nginx/html
CMD ["nginx", "-g", "daemon off;"]