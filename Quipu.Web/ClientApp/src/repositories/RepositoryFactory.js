import ProjectRepository from "./ProjectRepository";
import TaskRepository from "./TaskRepository";
import TaskStatusCategoryRepository from "./TaskStatusCategoryRepository";
import UserRepository from "./UserRepository";

const repositories = {
    projects: ProjectRepository,
    taskstatuscategories: TaskStatusCategoryRepository,
    tasks: TaskRepository,
    users: UserRepository,
};

export const RepositoryFactory = {
    get: name => repositories[name]
};