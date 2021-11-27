import { describe, expect, it } from "@jest/globals";
import { installQuasarPlugin } from "@quasar/quasar-app-extension-testing-unit-jest";
import { mount } from "@vue/test-utils";
import Row from "../../../src/components/ProjectComponents/ProjectTaskList_Row.vue";
import createStore from "app/src/store/index";

// Specify here Quasar config you'll need to test your component
installQuasarPlugin();

var store;
beforeAll(async () => {
  store = createStore();
  await store.dispatch("fetchProjects");
  await store.dispatch("fetchTasks");
  await store.dispatch("fetchTaskStatusCategories");
});

describe("Row", () => {
  let wrapper;

  beforeEach(() => {
    wrapper = mount(Row, {
      global: {
        plugins: [store],
      },
    });
  });

  it("renders", () => {
    expect(wrapper.exists()).toBeTruthy();
  });

  it("can assign name", () => {
    expect(0).toEqual(1);
  });

  it("can assign priority", () => {
    expect(0).toEqual(1);
  });

  it("can assign user", () => {
    expect(0).toEqual(1);
  });

  it("can assign date", () => {
    expect(0).toEqual(1);
  });

  it("can assign status", () => {
    expect(0).toEqual(1);
  });

  it("updates task", () => {
    expect(0).toEqual(1);
  });
});
