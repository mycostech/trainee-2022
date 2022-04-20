import axios from "axios";

const getAuthorizationHeader = () => {
  const token = localStorage.getItem("token");
  return token ? `Bearer ${token}` : "";
};

const customHeader = {
  "Content-Type": "application/json",
  "Access-Control-Allow-Origin": "*",
  "Access-Control-Allow-Methods": "GET,PUT,POST,DELETE,PATCH,OPTIONS",
  "Access-Control-Allow-Headers": "Content-Type, Authorization, Content-Length, X-Requested-With",
  "Access-Control-Allow-Credentials": "true",
  Authorization: getAuthorizationHeader(),
};

export const axiosHelper = {
  get: (url, params, header) => {
    return axios({
      method: "get",
      url: "http://localhost:5254" + url,
      headers: {
        ...customHeader,
        ...header,
      },
      params: params,
      validateStatus: () => true,
    }).then((response) => {
      return response;
    });
  },
  post: (url, data, header) => {
    return axios({
      method: "post",
      url: "http://localhost:5254" + url,
      headers: {
        ...customHeader,
        ...header,
      },
      data: data,
      validateStatus: () => true,
    }).then((response) => {
      return response;
    });
  },
};
