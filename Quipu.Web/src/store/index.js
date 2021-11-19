import { store } from "quasar/wrappers";
import { createStore } from "vuex";
import common from "./modules/common";
import prioritytypes from "./modules/prioritytypes";
import statuses from "./modules/statuses";
import users from "./modules/users";
import tasks from "./modules/tasks";
import taskstatuscategory from "./modules/taskstatuscategory";
import discussions from "./modules/discussions";
import projects from "./modules/projects";

export default store(function () {
  const Store = createStore({
    modules: {
      prioritytypes,
      statuses,
      users,
      common,
      tasks,
      taskstatuscategory,
      discussions,
      projects,
    },

    // enable strict mode (adds overhead!)
    // for dev mode and --debug builds only
    strict: process.env.DEBUGGING,
  });

  return Store;
});
