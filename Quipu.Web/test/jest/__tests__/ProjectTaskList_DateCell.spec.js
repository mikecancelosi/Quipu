import { describe, expect, it } from "@jest/globals";
import { installQuasarPlugin } from "@quasar/quasar-app-extension-testing-unit-jest";
import { mount } from "@vue/test-utils";
import Cell from "../../../src/components/ProjectComponents/ProjectTaskList_DateCell.vue";
import createStore from "app/src/store/index";

// Specify here Quasar config you'll need to test your component
installQuasarPlugin();

var store;
beforeAll(async () => {
  store = createStore();
  await store.dispatch("fetchUsers");
});

describe("DateCell", () => {
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

  it("shows value when necessary ", () => {
    expect(1).toEqual(0);
  });

  it("shows no value when necessary", () => {
    expect(1).toEqual(0);
  });

  it("shows calendar button on hover", () => {
    expect(1).toEqual(0);
  });

  it("shows calendar on click", () => {
    expect(1).toEqual(0);
  });

  it("changes display based on calendar selection", () => {
    expect(1).toEqual(0);
  });

  it("emits change event on selection", () => {
    expect(1).toEqual(0);
  });
});
