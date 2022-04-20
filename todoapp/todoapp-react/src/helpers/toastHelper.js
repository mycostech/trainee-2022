import { toast } from "react-hot-toast";
const toastJson = (json, type) => {
  Object.keys(json).forEach((key) => {
    if (type === "error") {
      toast.error(json[key]);
    } else if (type === "success") {
      toast.success(json[key]);
    } else {
      toast(json[key]);
    }
  });
};

export const toastHelper = {
  toastJson,
};
