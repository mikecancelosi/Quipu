import PriorityTypeRepository from "./../../repositories/PriorityTypeRepository";

const state = {
  priorityTypes: [],
  priorityDropdownOptions: [],
};

const getters = {
  allPriorityTypes: (state) => state.priorityTypes,
  allPriorityDropdownOptions: (state) => state.priorityDropdownOptions,
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
