// Production Repositories
import ProjectRepository from "./ProjectRepository";
import TaskRepository from "./TaskRepository";
import TaskStatusCategoryRepository from "./TaskStatusCategoryRepository";
import UserRepository from "./UserRepository";
import DiscussionRepository from "./DiscussionRepository";

//Testing Repositories
import UserTestRepository from "app/test/repos/UserTestRepository";
import TaskTestRepository from "app/test/repos/TaskTestRepository";
import TaskStatusCategoryTestRepository from "app/test/repos/TaskStatusCategoryTestRepository";
import DiscussionTestRepository from "app/test/repos/DiscussionTestRepository";
import ProjectTestRepository from "app/test/repos/ProjectTestRepository";

const isProductionEnv = process.env.NODE_ENV !== "test";
const repositories = {
  projects: isProductionEnv ? ProjectRepository : ProjectTestRepository,
  taskstatuscategories: isProductionEnv
    ? TaskStatusCategoryRepository
    : TaskStatusCategoryTestRepository,
  tasks: isProductionEnv ? TaskRepository : TaskTestRepository,
  users: isProductionEnv ? UserRepository : UserTestRepository,
  discussions: isProductionEnv
    ? DiscussionRepository
    : DiscussionTestRepository,
};

export const RepositoryFactory = {
  get: (name) => repositories[name],
};
