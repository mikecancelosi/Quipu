import ProjectRepository from "./../../repositories/ProjectRepository";

const state = {
  projects: [],
};

const getters = {
  getProjects: (state) => state.projects,
  getProjectByID: (state) => (id) => {
    const projectfound = state.projects.find((x) => x.id === id);
    return projectfound;
  },
};

const actions = {
  async fetchProjects({ commit }) {
    const projects = (await ProjectRepository.get()).data;
    commit("setProjects", projects);
  },

  updateProject({ commit }, project) {
    if (project.id !== 0 && project.id !== undefined) {
      ProjectRepository.put(project)
        .then((instance) =>
          commit("updateProject", JSON.parse(instance.config.data))
        )
        .catch((errorData) => alert(errorData.message));
    } else {
      ProjectRepository.post(project)
        .then((instance) =>
          commit("updateProject", JSON.parse(instance.config.data))
        )
        .catch((errorData) => alert(errorData.message));
    }
  },
};

const mutations = {
  setProjects: (state, projects) => {
    state.projects = projects;
  },
  updateProject: (state, project) => {
    const index = state.projects.findIndex((x) => x.id === project.id);
    if (index !== -1) {
      state.projects[index] = project;
    } else {
      state.projects.push(project);
    }
  },
};

export default {
  state,
  getters,
  actions,
  mutations,
};
