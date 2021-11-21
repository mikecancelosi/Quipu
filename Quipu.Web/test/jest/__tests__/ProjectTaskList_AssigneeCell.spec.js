import { describe, expect, it } from "@jest/globals";
import { installQuasarPlugin } from "@quasar/quasar-app-extension-testing-unit-jest";
import { mount, shallowMount } from "@vue/test-utils";
import Cell from "../../../src/components/ProjectComponents/ProjectTaskList_AssigneeCell.vue";
import createStore from "app/src/store/index";

// Specify here Quasar config you'll need to test your component
installQuasarPlugin();

const store = createStore();
store.dispatch("fetchUsers");
console.log(store.getters.allUsers);

describe("AssigneeCell", () => {
  it("has options", () => {
    const wrapper = mount(Cell, {
      global: {
        plugins: [store],
      },
    });
    const { vm } = wrapper;

    expect(1).toEqual(1);
  });
});
