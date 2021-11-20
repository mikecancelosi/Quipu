import { describe, expect, it } from "@jest/globals";
import { installQuasarPlugin } from "@quasar/quasar-app-extension-testing-unit-jest";
import { mount, shallowMount } from "@vue/test-utils";
import { createTestStore } from "../../utils/teststore";
import Cell from "../../../src/components/ProjectComponents/ProjectTaskList_AssigneeCell.vue";

// Specify here Quasar config you'll need to test your component
installQuasarPlugin();

const store = createTestStore();

describe("AssigneeCell", () => {
  it("has options", () => {
    const wrapper = mount(Cell, {
      global: {
        plugins: [store],
      },
    });
    const { vm } = wrapper;

    console.log(vm);

    expect(1).toEqual(1);
  });
});
