import ProjectRepository from "./ProjectRepository";
import TaskRepository from "./TaskRepository";
import TaskStatusCategoryRepository from "./TaskStatusCategoryRepository";
import UserRepository from "./UserRepository";
import DiscussionRepository from "./DiscussionRepository";

const repositories = {
  projects: ProjectRepository,
  taskstatuscategories: TaskStatusCategoryRepository,
  tasks: TaskRepository,
  users: UserRepository,
  discussions: DiscussionRepository,
};

export const RepositoryFactory = {
  get: (name) => repositories[name],
};
