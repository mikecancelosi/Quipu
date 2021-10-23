import "./styles/quasar.sass";
import iconSet from "quasar/icon-set/material-icons-outlined.js";
import "@quasar/extras/roboto-font/roboto-font.css";
import "@quasar/extras/material-icons/material-icons.css";
import "@quasar/extras/material-icons-outlined/material-icons-outlined.css";
import "@quasar/extras/mdi-v4/mdi-v4.css";

// To be used on app.use(Quasar, { ... })
export default {
  config: {
    dark: true,
  },
  plugins: {},
  iconSet: iconSet,
};
