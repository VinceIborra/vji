package vji.mvc;

import org.springframework.beans.BeansException;
import org.springframework.beans.factory.*;

/**
 *
 * @author vji
 */
public class ViewResolverImpl implements ViewResolver, BeanFactoryAware {

    private BeanFactory _beanFactory;

    public void setBeanFactory(BeanFactory bf) throws BeansException {
        _beanFactory = bf;
    }

    public BeanFactory getBeanFactory() { return _beanFactory; }

    public View resolve(String viewName) {
        return (View) getBeanFactory().getBean(viewName);
    }
}
