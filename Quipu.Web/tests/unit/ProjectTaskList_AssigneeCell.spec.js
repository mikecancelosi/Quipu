import { mount } from "@vue/test-utils";
import AssigneeCell from "../../src/components/ProjectComponents/ProjectTaskList_AssigneeCell.vue";
import { createStore } from "vuex";

const store = createStore({
  state() {
    return {
      users: [],
      userDropdownOptions: [],
    };
  },
  getters: {
    allUsers: (state) => state.users,
    allUserDropdownOptions(state) {
      return state.userDropdownOptions ?? [];
    },
    getUserByID: (state) => (id) => {
      return state.users.find((x) => x.id === id);
    },

    updateUser(user, { commit }) {
      UserRepository.post(user)
        .then((userinstance) => commit("updateUser", userinstance))
        .catch((errorData) => alert(errorData.message));
    },
  },

  mutations: {
    setUsers: (state, users) => {
      console.log(state, users);
    },
    setUserDropdownOptions: (state, useroptions) => {
      console.log(state, useroptions);
    },
    updateUser: (state, user) => {
      console.log(state, user);
    },
  },
});

describe("ProjectTaskList_AssigneeCell.vue", () => {
  it("Displays options", () => {
    const wrapper = mount(AssigneeCell, {
      global: {
        plugins: [store],
      },
    });

    console.log(wrapper.html());
  });
});
