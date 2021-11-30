import { RepositoryFactory } from "src/repositories/RepositoryFactory";
const PriorityTypeRepository = RepositoryFactory.get("priorities");

const state = {
  priorityTypes: [],
  priorityDropdownOptions: [],
};

const getters = {
  getPriorities: (state) => state.priorityTypes,
  getPriorityDropdownOptions: (state) => state.priorityDropdownOptions,
  getPriorityByID: (state) => (id) => {
    return state.priorityTypes.find((x) => x.id === id);
  },
};

const actions = {
  async fetchPriorityTypes({ commit }) {
    const priorities = (await PriorityTypeRepository.get()).data;
    const priorityoptions = [];
    priorities.forEach((priority) => {
      priorityoptions.push({
        label: priority.name,
        value: priority,
        category: priority.id,
      });
    });
    commit("setPriorityTypes", priorities);
    commit("setPriorityDropdownOptions", priorityoptions);
  },
};

const mutations = {
  setPriorityTypes: (state, priorities) => {
    state.priorityTypes = priorities;
  },
  setPriorityDropdownOptions: (state, options) => {
    state.priorityDropdownOptions = options;
  },
};

export default {
  state,
  getters,
  actions,
  mutations,
};
