import TaskStatusCategoryRepository from "../../repositories/TaskStatusCategoryRepository";

const state = {
  taskStatusCategories: [],
};

const getters = {
  getTaskStatusCategories: (state) => state.taskStatusCategories,
  getTaskStatusCategoryGroups: (state, store) => () => {
    const groups = [];
    state.taskStatusCategories.forEach((group) => {
      groups.push({
        id: group.id,
        name: group.name,
        expanded: true,
        tasks: store.getTasksByTaskStatusCategoryID(group.id),
      });
    });
    return groups;
  },
};

const actions = {
  async fetchTaskStatusCategories({ commit }) {
    const taskStatusCategories = (await TaskStatusCategoryRepository.get())
      .data;
    commit("setTaskStatusCategories", taskStatusCategories);
  },
};

const mutations = {
  setTaskStatusCategories: (state, categories) => {
    state.taskStatusCategories = categories;
  },
};

export default {
  state,
  getters,
  actions,
  mutations,
};
