import { describe, expect, it } from "@jest/globals";
import { installQuasarPlugin } from "@quasar/quasar-app-extension-testing-unit-jest";
import { mount } from "@vue/test-utils";
import Cell from "../../../src/components/ProjectComponents/ProjectTaskList_StatusCell.vue";
import createStore from "app/src/store/index";

// Specify here Quasar config you'll need to test your component
installQuasarPlugin();

var store;
beforeAll(async () => {
  store = createStore();
  await store.dispatch("fetchUsers");
});

describe("StatusCell", () => {
  let wrapper;

  beforeEach(() => {
    wrapper = mount(Cell, {
      global: {
        plugins: [store],
      },
    });
  });

  it("renders", () => {
    expect(wrapper.exists()).toBeTruthy();
  });

  it("has options", () => {
    expect(1).toEqual(0);
  });

  it("shows button on hover", () => {
    expect(1).toEqual(0);
  });

  it("shows dropdown on click", () => {
    expect(1).toEqual(0);
  });

  it("displays new value on selection", () => {
    expect(1).toEqual(0);
  });

  it("emits event on selection", () => {
    expect(1).toEqual(0);
  });
});
