import axios from "axios";

const baseDomain = "http://127.0.0.1:5000";
const baseURL = `${baseDomain}/api`;

export default axios.create({
  baseURL,
});
