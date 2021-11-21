import { describe, expect, it } from "@jest/globals";
import { installQuasarPlugin } from "@quasar/quasar-app-extension-testing-unit-jest";
import { mount } from "@vue/test-utils";
import Cell from "../../../src/components/ProjectComponents/ProjectTaskList_AssigneeCell.vue";
import { getStore } from "../jestSetup";

// Specify here Quasar config you'll need to test your component
installQuasarPlugin();

var store;
beforeEach(() => {
  store = getStore();
});

describe("AssigneeCell", () => {
  it("has options", () => {
    const wrapper = mount(Cell, {
      global: {
        plugins: [store],
      },
    });
    const { vm } = wrapper;

    expect(vm.allUserDropdownOptions.length).toBeGreaterThan(0);
  });
});
